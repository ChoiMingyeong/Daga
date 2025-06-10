import { drawBackground } from "/_content/DagaBlazorEngine/js/layer-background.js";
import { drawMain } from "/_content/DagaBlazorEngine/js/layer-main.js";
import { drawUI } from "/_content/DagaBlazorEngine/js/layer-ui.js";

let ctxDisplay;
let ctxBackground, ctxMain, ctxUI, ctxBuffer;

export function init(canvas, w, h) {
    ctxDisplay = canvas.getContext("2d");

    const create = () => new OffscreenCanvas(w, h).getContext("2d");

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

    if (width == 0 || height == 0) {
        return;
    })

    ctxBuffer.clearRect(0, 0, width, height);

    ctxBuffer.drawImage(ctxBackground.canvas, 0, 0);
    ctxBuffer.drawImage(ctxMain.canvas, 0, 0);
    ctxBuffer.drawImage(ctxUI.canvas, 0, 0);

    ctxDisplay.clearRect(0, 0, width, height);
    ctxDisplay.drawImage(ctxBuffer.canvas, 0, 0);
}