import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import "../App.css";

export default class Navigation extends Component {
  render() {
    return (
      <React.Fragment>
        <nav>
          <ul>
            <li>
              <NavLink to="/">Start</NavLink>
            </li>
            <li>
              <NavLink to="/About">About</NavLink>
            </li>
            <li>
              <NavLink to="/Contact">Contact</NavLink>
            </li>
          </ul>
        </nav>
      </React.Fragment>
    );
  }
}
