import React, { Component } from 'react'

export default class AdressList extends Component {
  render() {

    let AdressList = this.props.People.map((people) => {
        return <tr>
        <td>{people.name}</td>
        <td>{people.email}</td>
        <td>{people.phone}</td>
        </tr>
    })
    return (<table>{AdressList}</table>)
  }
}
