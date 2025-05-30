window.screenHelper = {
    getDimensions: () => {
        return {
            width: window.innerWidth,
            height: window.innerHeight
        };
    },
    registerResizeCallback: (dotNetObjectRef) => {
        window.onresize = () => {
            dotNetObjectRef.invokeMethodAsync('OnResize', {
                width: window.innerWidth,
                height: window.innerHeight
            });
        };
    }
};