export function init() {
    canvas = document.getElementById(canvasId);
    if (canvas && canvas.getContext)
        ctx = canvas.getContext('2d');
}

export function drawRect(x, y, width, height, fillColor, strokeColor) {
    if (!ctx)
        return;
    ctx.fillStyle = fillColor;
    ctx.fillRect(x, y, width, height);
    ctx.strokeStyle = strokeColor;
    ctx.strokeRect(x, y, width, height);
}

export function clear() {
    if (ctx && canvas)
        ctx.clearRect(0, 0, canvas.width, canvas.height);
}
