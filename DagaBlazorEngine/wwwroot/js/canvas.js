import { getScreenSize } from "/_content/DagaBlazorEngine/js/module-screensize.js";

let offscreen;
let offscreenCtx;

export function init() {
    const { w, h } = getScreenSize();
    offscreen = new OffscreenCanvas(w, h);
    offscreenCtx = offscreen.getContext("2d");
}

export function drawBegin(canvas) {
    if (!offscreenCtx || !canvas) return;

    const { w, h } = getScreenSize();
    canvas.width = w;
    canvas.height = h;
    offscreen.width = w;
    offscreen.height = h;

    offscreenCtx.clearRect(0, 0, canvas.width, canvas.height);
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

export function drawEnd(canvas) {
    if (!offscreen || !canvas) return;

    const targetCtx = canvas.getContext("2d");
    if (!targetCtx) return;
    
    targetCtx.clearRect(0, 0, canvas.width, canvas.height);
    targetCtx.drawImage(offscreen, 0, 0);
}