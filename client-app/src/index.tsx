import * as React from "react";
import * as ReactDOM from "react-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
import "bootstrap/dist/css/bootstrap.css";
import "./index.css";
import * as Clipboard from "clipboard";

new Clipboard(".btn");

ReactDOM.render(
    <App />,
    document.getElementById("root") as HTMLElement
);
registerServiceWorker();