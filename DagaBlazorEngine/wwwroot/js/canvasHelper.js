const ctxCache = {
    canvas: null,
    ctx: null,
    imageCache: new Map(),
    frameCache: new Map(),
    uiCache: new Map()
};

export function drawRectangle(canvas, x, y, width, height, color = "green") {
    if (!canvas) return;

    const ctx = canvas.getContext("2d");
    if (!ctx) return;

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.strokeStyle = color;
    ctx.lineWidth = 2;
    ctx.strokeRect(x, y, width, height);
}

export function init(canvasId) {
    ctxCache.canvas = document.getElementById(canvasId);
    if (ctxCache.canvas)
        ctxCache.ctx = ctxCache.canvas.getContext("2d");
}

export function preloadImage(key, url) {
    return new Promise((resolve, reject) => {
        if (ctxCache.imageCache.has(key)) return resolve(true);
        const img = new Image();
        img.onload = () => {
            ctxCache.imageCache.set(key, img);
            resolve(true);
        };
        img.onerror = reject;
        img.src = url;
    });
}

// 프레임 (Sprite + Collider 포함)
export function preloadFrame(key, frameData) {
    ctxCache.frameCache.set(key, frameData); // { sprite: ..., collider: ... }
}

export function drawFrame(key) {
    const ctx = ctxCache.ctx;
    const frame = ctxCache.frameCache.get(key);
    if (!ctx || !frame) return;

    if (frame.sprite) {
        const img = ctxCache.imageCache.get(frame.sprite.imageKey);
        if (img) {
            ctx.drawImage(img, frame.sprite.x, frame.sprite.y, frame.sprite.width, frame.sprite.height);
        }
    }

    if (frame.collider) {
        drawCollider(frame.collider);
    }
}

// Collider 전용 렌더
export function drawCollider(collider) {
    const ctx = ctxCache.ctx;
    if (!ctx || !collider) return;
    ctx.beginPath();
    ctx.strokeStyle = collider.strokeColor || "red";

    if (collider.type === "rect") {
        ctx.strokeRect(collider.x, collider.y, collider.width, collider.height);
    } else if (collider.type === "circle") {
        ctx.arc(collider.x, collider.y, collider.radius, 0, Math.PI * 2);
        ctx.stroke();
    }
}

// UI 요소
export function preloadUI(key, uiData) {
    ctxCache.uiCache.set(key, uiData); // { type, x, y, text, etc }
}

export function drawUI(key) {
    const ctx = ctxCache.ctx;
    const ui = ctxCache.uiCache.get(key);
    if (!ctx || !ui) return;

    ctx.fillStyle = ui.fillStyle || "white";
    ctx.font = ui.font || "16px Arial";

    if (ui.type === "text") {
        ctx.fillText(ui.text, ui.x, ui.y);
    } else if (ui.type === "rect") {
        ctx.fillRect(ui.x, ui.y, ui.width, ui.height);
    }
}
