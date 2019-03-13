import React from 'react'
import ReactDOM from 'react-dom'


class NewsArticle extends React.Component{
    render(){
        return (<div>
            <h1>HEADLINE!</h1>
            <p>This is some news text</p>
            </div>);
    }

}

ReactDOM.render(<div>
<NewsArticle />
</div>, document.querySelector("#root"));