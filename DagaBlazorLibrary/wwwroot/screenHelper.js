window.screenHelper = {
    getDimensions: () => {
        return {
            X: window.innerWidth,
            Y: window.innerHeight
        };
    },
    registerResizeCallback: (dotNetObjectRef) => {
        window.onresize = () => {
            dotNetObjectRef.invokeMethodAsync('OnResize', {
                X: window.innerWidth,
                Y: window.innerHeight
            });
        };
    }
};