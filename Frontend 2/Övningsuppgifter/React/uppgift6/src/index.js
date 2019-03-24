import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import * as serviceWorker from "./serviceWorker";
import HelloReact from "./components/HelloComponent";
import Message from "./components/Message";
import Product from "./components/Product";
import Fruitlist from "./components/Fruitlist";
import AdressList from "./components/AdressList";
import NewsList from "./components/NewsList";
import Hello from "./components/Hello";
import Figure from "./components/Figure";

export {
  HelloReact,
  Message,
  Product,
  Fruitlist,
  AdressList,
  NewsList,
  Hello,
  Figure,
};

ReactDOM.render(<App />, document.getElementById("root"));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
