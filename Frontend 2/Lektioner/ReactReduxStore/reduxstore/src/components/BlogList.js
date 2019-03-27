import React, { Component } from "react";
import { connect } from "react-redux";
import deletePost from '../actions/deleteAction'

class BlogList extends Component {
  render() {
    let allItems = this.props.posts.map(post => {
      return (
        <div key={post.id}>
          <h2>{post.title}</h2>
          <p>{post.body}</p>
          <button onClick={() => {this.props.deleteBlogPost(post.id)}}>Delete</button>
        </div>
      );
    });
    return <React.Fragment>{allItems}</React.Fragment>;
  }
}

function mapDispatchToProps(dispatch) {
    return {
        deleteBlogPost: (id) => { dispatch(deletePost(id)) }
    }

}

function mapStateToProps(state) {
  return {
    posts: state.posts
  };
}
export default connect(mapStateToProps, mapDispatchToProps)(BlogList);
