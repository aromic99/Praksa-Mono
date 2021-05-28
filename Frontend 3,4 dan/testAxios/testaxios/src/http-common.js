import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:44305/api",
  headers: {
    "Content-type": "text/xml"
  }
});