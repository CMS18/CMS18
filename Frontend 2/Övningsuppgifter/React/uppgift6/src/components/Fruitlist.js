import React, { Component } from 'react'

export default class Fruitlist extends Component {
  render() {
      let Fruitlist = this.props.array.map((fruits) => {
          return <li>{fruits}</li>;
      });

    return (<ul>{Fruitlist}</ul>)
  }
}
