
import React, { Component } from 'react';
class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      books : [],
      isLoaded : false,
    }
  }
  componentDidMount () {
    
    fetch('https://localhost:44305/api/book')
      .then(res => res.json())
      .then(json => {
        this.setState({
          isLoaded : true,
         
          books : json
        })
      
      });
  }


  render () {

    var {isLoaded, books} = this.state ;

    if(!isLoaded){
      return <div>Loading</div>
    }
    else {
      return (
        <div className="App">
          <ul>
            {books.map(book => (
              <li key = {book.Id}>
                 Name : {book.Name} | Year : {book.Year}  |  AuthorID : {book.AuthorID}
              </li>
            ))}
          </ul>
        </div>
      )
      }
  };
}

export default App