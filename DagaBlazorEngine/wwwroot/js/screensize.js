export function getScreenSize() {
    const dpr = window.devicePixelRatio || 1;
    const width = window.innerWidth * dpr;
    const height = window.innerHeight * dpr;

    return {
        Width: width,
        Height: height
    };
}