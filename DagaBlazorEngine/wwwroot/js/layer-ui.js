export function draw(ctx, label) {
    ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
    ctx.fillStyle = "black";
    ctx.font = "20px sans-serif";
    ctx.fillText(label, 10, 30);
}