import React, { Component } from "react";
import { Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import AddBook from "./components/add_book.component";
import Book from "./components/book.component";
import BookList from "./components/booklist.component";

class App extends Component {
  render() {
    return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <a href="/book" className="navbar-brand">
            BooooksList
          </a>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/book"} className="nav-link">
                Books
              </Link>
            </li>
            <li className="nav-item">
              <Link to={"/add"} className="nav-link">
                Add
              </Link>
            </li>
          </div>
        </nav>

        <div className="container mt-3">
          <Switch>
            <Route exact path={["/" , "/book"]} component={BookList} />
            <Route exact path="/add" component={AddBook} />
            <Route path="/book" component={Book} />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;