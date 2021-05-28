import React, { Component } from "react";
import {Button} from "reactstrap";
import BookDataService from "../services/book.service";

export default class Book extends Component {
  constructor(props) {
    super(props);
    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeYear = this.onChangeYear.bind(this);
    this.onChangeAuthorID = this.onChangeAuthorID.bind(this);
    this.getBook = this.getBook.bind(this);
    this.updateBook = this.updateBook.bind(this);
    this.deleteBook = this.deleteBook.bind(this);

    this.state = {
      currentBook: {
        id: null,
        name: "",
        year : null,
        authorid:null
      },
      message: ""
    };
  }

  componentDidMount() {
    this.getBook(this.props.match.params.id);
  }

  onChangeName(e) {
    const name = e.target.value;

    this.setState(function(prevState) {
      return {
        currentBook: {
          ...prevState.currentName,
          name : name
        }
      };
    });
  }

  onChangeYear(e) {
    const year = e.target.value;
    
    this.setState(prevState => ({
      currentBook: {
        ...prevState.currentBook,
        year:year
      }
    }));
  }
  onChangeAuthorID(e) {
    const authorid = e.target.value;
    
    this.setState(prevState => ({
      currentBook: {
        ...prevState.currentBook,
        authorid : authorid 
      }
    }));
  }

  getBook(id) {
    BookDataService.get(id)
      .then(response => {
        this.setState({
          currentBook: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  updateBook() {
    BookDataService.put(
      this.state.currentBook.ID,
      this.state.currentBook
    )
      .then(response => {
        console.log(response.data);
        this.setState({
          message: "The book was updated successfully!"
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  deleteBook() {    
    BookDataService.delete(this.state.currentBook.id)
      .then(response => {
        console.log(response.data);
        this.props.history.push('/book')
      })
      .catch(e => {
        console.log(e);
      });
  }

  render() {
    const { currentBook } = this.state;

    return (
      <div>
        {currentBook ? (
          <div className="edit-form">
            <h4>Book</h4>
            <form>
              <div className="form-group">
                <label htmlFor="Name">Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="Name"
                  value={currentBook.name}
                  onChange={this.onChangeName}
                />
              </div>
              <div className="form-group">
                <label htmlFor="year">Year</label>
                <input
                  type="text"
                  className="form-control"
                  id="Year"
                  value={currentBook.year}
                  onChange={this.onChangeYear}
                />
              </div>

              <div className="form-group">
                <label htmlFor="authorid">AuthorID</label>
                <input
                  type="text"
                  className="form-control"
                  id="AuthorID"
                  value={currentBook.year}
                  onChange={this.onChangeAuthorID}
                />
              </div>
            </form>
            
            <Button
              color = "danger"
              className="badge badge-danger mr-2"
              onClick={this.deleteBook}
            >
              Delete
            </Button>

            <Button
              
              type="submit"
              color = "success"
              className="badge badge-success"
              onClick={this.updateBook}
            >
              Update
            </Button>
            <p>{this.state.message}</p>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a Book...</p>
          </div>
        )}
      </div>
    );
  }
}