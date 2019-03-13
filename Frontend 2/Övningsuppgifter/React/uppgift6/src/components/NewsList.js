import React, { Component } from 'react'

export default class NewsList extends Component {
  render() {
      let NewsList = this.props.News.map((NewsList) => {
          return <div>
          <h3>{NewsList.title}</h3>
           <p>{NewsList.text}</p>
           </div>
      })
    return (
      <div>
        {NewsList}
      </div>
    )
  }
}
