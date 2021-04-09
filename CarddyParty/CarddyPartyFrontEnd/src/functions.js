export default class APIReturn {
  static testAPI() {
    return new Promise(function (resolve, reject) {
      let request = new XMLHttpRequest();
      const api = `http://localhost:5000/api/Cards/recent`;
      request.onload = function () {
        if (this.status === 200) {
          resolve(request.response);
        } else {
          reject(request.response);
        }
      };
      request.open("GET", api, true);
      request.send();
    });
  }

  //Fetch Prompts
  static promptAPI() {
    return new Promise(function (resolve, reject) {
      let request = new XMLHttpRequest();
      const api = `http://localhost:5000/api/Prompts/random`;
      request.onload = function () {
        if (this.status === 200) {
          resolve(request.response);
        } else {
          reject(request.response);
        }
      };
      request.open("GET", api, true);
      request.send();
    });
  }

  static promptAPITheme(theme) {
    return new Promise(function (resolve, reject) {
      let request = new XMLHttpRequest();
      const api = `http://localhost:5000/api/Prompts?theme=${theme}`;
      request.onload = function () {
        if (this.status === 200) {
          resolve(request.response);
        } else {
          reject(request.response);
        }
      };
      request.open("GET", api, true);
      request.send();
    });
  }

  //Submit Prompts
  static submitAPI() {
    return new Promise(function () {
      let answer = document.getElementById("answer").value;
      
      // This will be the Player ID - it grabs the DIV text
      let id = document.getElementById('playerId').textContent;

      var http = new XMLHttpRequest();
      var url = 'http://localhost:5000/api/Cards';
      // var url = '/server';
      // var params = `answer=${answer}&playerID=${id}`;
      http.open('POST', url, true);
      

      //Send the proper header information along with the request
      http.setRequestHeader('Content-type', 'application/json;charset=UTF-8');
      
      http.onreadystatechange = function () {
        // Call a function when the state changes.
        if (http.readyState == 4 && http.status == 200) {
          alert(http.responseText);
        }
      };

      var params = new Object();
      params.answer = answer;
      params.playerID = id;

      // Turn the data object into an array of URL-encoded key/value pairs.
      let urlEncodedDataPairs = [], name;
      for (name in params) {
        urlEncodedDataPairs.push(encodeURIComponent(name) + '=' + encodeURIComponent(params[name]));
      }

      http.send(JSON.stringify(params));
      // console.log(JSON.stringify(params));
    });
  }
  // put response
  static selectAPI(selectedcard) {
    return new Promise(function () {
      console.log(selectedcard);
      var params = new Object();
      params.selectedcard = parseInt(selectedcard);
      var http = new XMLHttpRequest();
      var url = 'http://localhost:5000/api/Selects';
      http.open('POST', url, true);
      

      //Send the proper header information along with the request
      http.setRequestHeader('Content-type', 'application/json; charset=UTF-8');
      
      http.onreadystatechange = function () {
        // Call a function when the state changes.
        if (http.readyState == 4 && http.status == 200) {
          alert(http.responseText);
        }
      };
      console.log(selectedcard);

      http.send(JSON.stringify(params));
      // console.log(JSON.stringify(params));
    });
  }
  static grabSelect2(id) {
    return new Promise(function (resolve, reject) {
      let request = new XMLHttpRequest();
      const api = `http://localhost:5000/api/Cards/${id}`;
      request.onload = function () {
        if (this.status === 200) {
          resolve(request.response);
        } else {
          reject(request.response);
        }
      };
      request.open("GET", api, true);
      request.send();
    });
  }
  static grabSelect1() {
    return new Promise(function (resolve, reject) {
      let request = new XMLHttpRequest();
      const api = `http://localhost:5000/api/Selects`;
      request.onload = function () {
        if (this.status === 200) {
          resolve(request.response);
        } else {
          reject(request.response);
        }
      };
      request.open("GET", api, true);
      request.send();
    });
  }
}