window.canvasHelper = (function () {
    let ctx = null;
    let canvas = null;

    return {
        init: function (canvasId) {
            canvas = document.getElementById(canvasId);
            if (canvas && canvas.getContext) {
                ctx = canvas.getContext('2d');
            }
        },
        drawRect: function (x, y, width, height, fillColor, strokeColor) {
            if (!ctx) return;
            ctx.fillStyle = fillColor;
            ctx.fillRect(x, y, width, height);
            ctx.strokeStyle = strokeColor;
            ctx.strokeRect(x, y, width, height);
        },
        clear: function () {
            if (ctx && canvas) {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
            }
        }
    };
})();
