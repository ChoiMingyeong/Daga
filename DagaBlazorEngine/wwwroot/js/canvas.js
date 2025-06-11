import { getScreenSize } from "/_content/DagaBlazorEngine/js/module-screensize.js";

let targetCtx;
let offscreen;
let offscreenCtx;

export function init(canvas) {
    targetCtx = canvas.getContext("2d");
    offscreen = new OffscreenCanvas(canvas.width, canvas.height);
    offscreenCtx = offscreen.getContext("2d");
}

export function drawBegin() {
    if (!offscreenCtx) return;

    const { w, h } = getScreenSize();
    targetCtx.canvas.width = w;
    targetCtx.canvas.height = h;
    offscreen.width = w;
    offscreen.height = h;

    offscreenCtx.clearRect(0, 0, offscreen.width, offscreen.height);
}

export function drawFillRect(x, y, w, h, c = "black") {
    if (!offscreenCtx) return;
    offscreenCtx.fillStyle = c;
    offscreenCtx.fillRect(x, y, w, h);
}

export function drawStrokeRect(x, y, w, h, l = 2, c = "green") {
    if (!offscreenCtx) return;
    offscreenCtx.lineWidth = l;
    offscreenCtx.strokeStyle = c;
    offscreenCtx.strokeRect(x, y, w, h);
}

export function drawEnd() {
    if (!offscreen || !targetCtx) return;
    targetCtx.clearRect(0, 0, targetCtx.canvas.width, targetCtx.canvas.height);
    targetCtx.drawImage(offscreen, 0, 0);
}