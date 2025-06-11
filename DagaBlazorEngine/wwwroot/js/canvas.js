import { getScreenSize } from "/_content/DagaBlazorEngine/js/screensize.js";

let targetCtx;
let offscreen;
let offscreenCtx;

export function init(canvas) {
    targetCtx = canvas.getContext("2d");
    offscreen = new OffscreenCanvas(canvas.width, canvas.height);
    offscreenCtx = offscreen.getContext("2d");

    resizeCanvas();
    window.addEventListener("resize", resizeCanvas);
}

function resizeCanvas() {
    if (!targetCtx || !offscreen) return;

    const { Width, Height } = getScreenSize();
    targetCtx.canvas.width = Width;
    targetCtx.canvas.height = Height;

    offscreen.width = Width;
    offscreen.height = Height;
}

export function drawBegin() {
    if (!offscreenCtx) return;

    offscreenCtx.clearRect(0, 0, offscreen.width, offscreen.height);
}

export function drawFillRect(x, y, w, h, c = "gray") {
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

export function drawFillCircle(x, y, r, c = "gray") {
    if (!offscreenCtx) return;

    offscreenCtx.beginPath();
    offscreenCtx.arc(x, y, r, 0, Math.PI * 2);
    offscreenCtx.fillStyle = c;
    offscreenCtx.fill();
}
export function drawStrokeCircle(x, y, r, l = 2, c = "green") {
    if (!offscreenCtx) return;

    offscreenCtx.beginPath();
    offscreenCtx.arc(x, y, r, 0, Math.PI * 2);
    offscreenCtx.lineWidth = l;
    offscreenCtx.strokeStyle = c;
    offscreenCtx.stroke();
}
export function drawText(t, x, y, s = 20, f = "sans-serif", c = "black", a = "left", b = "top") {
    if (!offscreenCtx) return;

    offscreenCtx.font = `${s}px ${f}`;
    offscreenCtx.fillStyle = c;
    offscreenCtx.textAlign = a;
    offscreenCtx.textBaseline = b;
    offscreenCtx.fillText(t, x, y);
}

export async function drawImage(url, x, y, w = 0, h = 0) {
    if (!offscreenCtx) return;

    let image = new Image();
    image.src = url;

    await image.decode();
    let width = w <= 0 ? image.naturalWidth : w;
    let height = h <= 0 ? image.naturalHeight : h;
    offscreenCtx.drawImage(image, x, y, width, height);
}

export function drawEnd() {
    if (!offscreen || !targetCtx) return;

    targetCtx.clearRect(0, 0, targetCtx.canvas.width, targetCtx.canvas.height);
    targetCtx.drawImage(offscreen, 0, 0);
}