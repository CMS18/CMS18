import React, { Component } from 'react'
import styles from './appStyles.module.css'

export default class NewsList extends Component {
  render() {
      let NewsList = this.props.News.map((NewsList) => {
          return <div className={styles.title}>
          <h3>{NewsList.title}</h3>
           <p className={styles.content}>{NewsList.text}</p>
           </div>
      })
    return (
      <div>
        {NewsList}
      </div>
    )
  }
}
