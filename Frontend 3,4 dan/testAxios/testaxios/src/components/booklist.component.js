import React, { Component } from "react";
import BookDataService from "../services/book.service";


export default class BookList extends Component {
  constructor(props) {
    super(props);
    this.retrieveBooks = this.retrieveBooks.bind(this);
    this.refreshList = this.refreshList.bind(this);
    this.setActiveBook = this.setActiveBook.bind(this);


    this.state = {
      books: [],
      currentBook: null,
      currentIndex: -1,
    };
  }

  componentDidMount() {
    this.retrieveBooks();
  }

  retrieveBooks() {
    BookDataService.getAll()
      .then(response => {
        this.setState({
          books: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  refreshList() {
    this.retrieveBooks();
    this.setState({
      currentBook: null,
      currentIndex: -1
    });
  }

  setActiveBook(book, index) {
    this.setState({
      currentBook: book,
      currentIndex: index
    });
  }

  render() {
    const Link = require("react-router-dom").Link;
    const { books, currentBook, currentIndex } = this.state;
    return (
        <div className="list row">
          <div className="col-md-6">
            <h4>List of Books</h4>

            <ul className="list-group">
                {books &&
                books.map((book, index) => (
                    <li
                    className={
                        "list-group-item " +
                        (index === currentIndex ? "active" : "")
                    }
                    onClick={() => this.setActiveBook(book, index)}
                    key={index}
                    >
                    {book.Name}
                    </li>
                ))}
            </ul>
          </div>
          <div className="col-md-6">
            {currentBook ? (
            <div>
                <h4>Book</h4>
                <div>
                <label>
                    <strong>Name:</strong>
                </label>{" "}
                {currentBook.Name}
                </div>
                <div>
                <label>
                    <strong>Year:</strong>
                </label>{" "}
                {currentBook.Year}
                </div>
                <div>
                <label>
                    <strong>AuthorID:</strong>
                </label>{" "}
                {currentBook.AuthorID}
                </div>
                <Link
                  color = "danger"
                  to={"/book/" + currentBook.ID}
                  className="badge badge-warning"
                >
                    Edit
                </Link>
                </div>
            ) : (
                <div>
                <br />
                <p>Please click on a Book...</p>
                </div>
            )}
            </div>
        </div>
      
      
    );
  }
}

