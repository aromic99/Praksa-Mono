import React, { Component } from "react";
import BookDataService from "../services/book.service";

export default class AddBook extends Component {
  constructor(props) {
    super(props);
    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeYear = this.onChangeYear.bind(this);
    this.onChangeAuthorID = this.onChangeAuthorID.bind(this);
    this.saveBook = this.saveBook.bind(this);
    this.newBook = this.newBook.bind(this);

    this.state = {
      name: "",
      year: "", 
      authorID : "",

      submitted: false
    };
  }

  onChangeName(e) {
    this.setState({
      name: e.target.value
    });
  }

  onChangeYear(e) {
    this.setState({
      year: e.target.value
    });
  }
  onChangeAuthorID(e) {
      this.setState({
        authorID:e.target.value
      });
  }

  saveBook() {
    var data = {
      Name: this.state.Name,
      Year: this.state.Year,
      AuthorID : this.state.AuthorID
    };

    BookDataService.post(data)
      .then(response => {
        this.setState({
          Name : response.data.Name,
          Year : response.data.Year,
          authorID : response.data.AuthorID,

          submitted: true
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  newBook() {
    this.setState({
      name: "",
      year: "",
      authorID : "",

      submitted: false
    });
  }

  render() {
    return (
      <div className="submit-form">
        {this.state.submitted ? (
          <div>
            <h4>You submitted successfully!</h4>
            <button className="btn btn-success" onClick={this.newTutorial}>
              Add
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="Name">Name</label>
              <input
                type="text"
                className="form-control"
                id="Name"
                required
                value={this.state.Name}
                onChange={this.onChangeName}
                name="Name"
              />
            </div>

            <div className="form-group">
              <label htmlFor="Year">Year</label>
              <input
                type="text"
                className="form-control"
                id="Year"
                required
                value={this.state.Year}
                onChange={this.onChangeYear}
                name="Year"
              />
            </div>

            <div className="form-group">
              <label htmlFor="AuthorID">AuthorID</label>
              <input
                type="text"
                className="form-control"
                id="AuthorID"
                required
                value={this.state.AuthorID}
                onChange={this.onChangeAuthorID}
                name="AuthorID"
              />
            </div>

            <button onClick={this.saveBook} className="btn btn-success">
              Submit
            </button>
          </div>
        )}
      </div>
    );
  }
}
