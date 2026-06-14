export function register (reference) {
    console.log("Registering");
    window.addEventListener("storage", (event) => {
        console.log("Triggered");
        if (event.key === "authUser") {
            console.log("Calling");
            reference.invokeMethodAsync("OnAuthenticationChanged");
        }
    });
}