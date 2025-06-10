let ctxDisplay;
let ctxBackground, ctxMain, ctxUI, ctxBuffer;

export function init(canvas) {
    ctxDisplay = canvas.getContext("2d");

    const width = ctxDisplay.canvas.width;
    const height = ctxDisplay.canvas.height;

    const create = () => new OffscreenCanvas(width, height).getContext("2d");

    ctxBackground = create();
    ctxMain = create();
    ctxUI = create();
    ctxBuffer = create();
}

export function getCtxBackground() {
    return ctxBackground;
}
export function getCtxMain() {
    return ctxMain;
}
export function getCtxUI() {
    return ctxUI;
}

export function flush() {
    const width = ctxDisplay.canvas.width;
    const height = ctxDisplay.canvas.height;

    ctxBuffer.clearRect(0, 0, width, height);

    ctxBuffer.drawImage(ctxBackground.canvas, 0, 0);
    ctxBuffer.drawImage(ctxMain.canvas, 0, 0);
    ctxBuffer.drawImage(ctxUI.canvas, 0, 0);

    ctxDisplay.clearRect(0, 0, width, height);
    ctxDisplay.drawImage(ctxBuffer.canvas, 0, 0);
}