import React, { Component } from 'react'

export default class Message extends Component {
  render() {
    return (
      <div>
        <h3>{this.props.Message}</h3>
        <h3>{this.props.Message2}</h3>
        <p>{this.props.messageDate}</p>
      </div>
    )
  }
}
