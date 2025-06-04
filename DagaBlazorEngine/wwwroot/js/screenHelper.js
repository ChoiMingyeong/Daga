export function getScreenSize() {
    return {
        X: window.innerWidth,
        Y: window.innerHeight
    };
}

export function resizeCallback(dotNetObjectRef) {
    window.onresize = () => {
        dotNetObjectRef.invokeMethodAsync('OnResize', {
            X: window.innerWidth,
            Y: window.innerHeight
        });
    };
}