let gl;
let program;
let positionBuffer;
let positionLocation;
let colorUniform;
export function init(canvas) {
    gl = canvas.getContext("webgl");
    if (!gl) {
        console.error("WebGL not supported.");
        return;
    }

    // 셰이더 컴파일 및 프로그램 생성
    const vertexShaderSource = `
        attribute vec2 a_position;
        uniform vec2 u_resolution;
        void main() {
            vec2 zeroToOne = a_position / u_resolution;
            vec2 zeroToTwo = zeroToOne * 2.0;
            vec2 clipSpace = zeroToTwo - 1.0;

            gl_Position = vec4(clipSpace * vec2(1, -1), 0, 1);
        }
    `;

    const fragmentShaderSource = `
        precision mediump float;
        uniform vec4 u_color;
        void main() {
            gl_FragColor = u_color;
        }
    `;

    const vertexShader = createShader(gl.VERTEX_SHADER, vertexShaderSource);
    const fragmentShader = createShader(gl.FRAGMENT_SHADER, fragmentShaderSource);
    program = createProgram(vertexShader, fragmentShader);

    positionLocation = gl.getAttribLocation(program, "a_position");
    colorUniform = gl.getUniformLocation(program, "u_color");

    // 버퍼 생성
    positionBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, positionBuffer);

    resizeCanvas(); // 사이즈 및 viewport 초기화
    window.addEventListener("resize", resizeCanvas);
}
function createShader(type, source) {
    const shader = gl.createShader(type);
    gl.shaderSource(shader, source);
    gl.compileShader(shader);

    const success = gl.getShaderParameter(shader, gl.COMPILE_STATUS);
    if (!success) {
        console.error(gl.getShaderInfoLog(shader));
        gl.deleteShader(shader);
        return null;
    }
    return shader;
}

function createProgram(vertexShader, fragmentShader) {
    const program = gl.createProgram();
    gl.attachShader(program, vertexShader);
    gl.attachShader(program, fragmentShader);
    gl.linkProgram(program);

    const success = gl.getProgramParameter(program, gl.LINK_STATUS);
    if (!success) {
        console.error(gl.getProgramInfoLog(program));
        gl.deleteProgram(program);
        return null;
    }
    return program;
}
function resizeCanvas() {
    const { Width, Height } = getScreenSize();

    gl.canvas.width = Width;
    gl.canvas.height = Height;
    gl.viewport(0, 0, gl.canvas.width, gl.canvas.height);
}
export function drawFillRect(x, y, w, h, color = [0.5, 0.5, 0.5, 1]) {
    gl.useProgram(program);
    gl.bindBuffer(gl.ARRAY_BUFFER, positionBuffer);

    const positions = [
        x, y,
        x + w, y,
        x, y + h,
        x, y + h,
        x + w, y,
        x + w, y + h
    ];
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(positions), gl.STATIC_DRAW);

    gl.enableVertexAttribArray(positionLocation);
    gl.vertexAttribPointer(positionLocation, 2, gl.FLOAT, false, 0, 0);

    gl.uniform4fv(colorUniform, color);

    const resolutionUniform = gl.getUniformLocation(program, "u_resolution");
    gl.uniform2f(resolutionUniform, gl.canvas.width, gl.canvas.height);

    gl.drawArrays(gl.TRIANGLES, 0, 6);
}
export function drawBegin() {
    gl.clearColor(0.1, 0.1, 0.1, 1.0);
    gl.clear(gl.COLOR_BUFFER_BIT);
}

export function drawEnd() {
    // WebGL은 자체적으로 drawEnd 필요 없음
    // 렌더 루프 내에서 drawBegin -> drawXXX -> nextFrame 순환만 필요
}
