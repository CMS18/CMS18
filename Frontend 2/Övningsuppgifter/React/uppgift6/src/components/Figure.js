import React, { Component } from "react";

export default class Figure extends Component {
  render() {
    // var color = {
    //   height: "100px",
    //   width: "100px",
    //   backgroundColor: this.props.bgColor
    // };

    var flag = {
      width: this.props.w,
      height: this.props.h,
      backgroundColor: this.props.background,     
    };
    return (
    <div style={flag}></div>
    );
  }
}
