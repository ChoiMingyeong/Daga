export function getScreenSize() {
    return {
        X: window.innerWidth,
        Y: window.innerHeight
    };
}

export function resizeCallback(dotNetObjectRef) {
    function notifyResize() {
        dotNetObjectRef.invokeMethodAsync("OnResize", {
            X: window.innerWidth,
            Y: window.innerHeight
        });
    }

    window.onresize = notifyResize;
    notifyResize();
}