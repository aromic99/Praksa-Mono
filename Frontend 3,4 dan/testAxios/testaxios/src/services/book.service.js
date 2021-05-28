import http from "../http-common";

class BookDataService {
  getAll() {
    return http.get("/book");
  }

  get(id) {
    return http.get(`/book/${id}`);
  }

  post(data) {
    return http.post("/book", data);
  }

  put(id, data) {
    return http.put(`/book/${id}`, data);
  }

  delete(id) {
    return http.delete(`/book/${id}`);
  }

}

export default new BookDataService();