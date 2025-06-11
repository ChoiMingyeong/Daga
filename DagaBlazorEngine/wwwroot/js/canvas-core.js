const canvas = document.getElementById("mainCanvas");
const offscreen = canvas.transferControlToOffscreen();

const worker = new Worker("/_content/DagaBlazorEngine/js/render-worker.js");
worker.postMessage({ type: "init", canvas: offscreen }, [offscreen]);

function resizeCanvas() {
    const dpr = window.devicePixelRatio || 1;
    const width = window.innerWidth * dpr;
    const height = window.innerHeight * dpr;

    canvas.width = width;
    canvas.height = height;
    canvas.style.width = `${window.innerWidth}px`;
    canvas.style.height = `${window.innerHeight}px`;

    worker.postMessage({ type: "resize", width, height });
}

window.addEventListener("resize", resizeCanvas);