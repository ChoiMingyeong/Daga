export function drawBackground(ctx) {
    ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
    ctx.fillStyle = "#f0f0f0";
    ctx.fillRect(0, 0, ctx.canvas.width, ctx.canvas.height);
}