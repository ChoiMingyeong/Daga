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

        drawImage: function (imageUrl, x, y, width, height) {
            if (!ctx) return;
            const img = new Image();
            img.onload = function () {
                ctx.drawImage(img, x, y, width, height);
            };
            img.src = imageUrl;
        },

        preloadImage: function (key, src, onLoaded) {
            const img = new Image();
            img.onload = () => {
                images[key] = img;
                if (onLoaded) onLoaded();
            };
            img.src = src;
        },

        drawFrame: function (key, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight) {
            if (!ctx || !images[key]) return;
            ctx.drawImage(images[key], sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);
        },

        startAnimation: function (key, frameWidth, frameHeight, frameCount, intervalMs) {
            let frame = 0;

            function loop() {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                const sx = frame * frameWidth;
                const sy = 0;
                ctx.drawImage(images[key], sx, sy, frameWidth, frameHeight, 0, 0, frameWidth, frameHeight);

                frame = (frame + 1) % frameCount;
                setTimeout(() => requestAnimationFrame(loop), intervalMs);
            }

            requestAnimationFrame(loop);
        },

        clear: function () {
            if (ctx && canvas) {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
            }
        },
    };
})();
