export function getDimensions() {
    return {
        X: window.innerWidth,
        Y: window.innerHeight
    };
}

export function registerResizeCallback(dotNetObjectRef) {
    window.onresize = () => {
        dotNetObjectRef.invokeMethodAsync('OnResize', {
            X: window.innerWidth,
            Y: window.innerHeight
        });
    };
}