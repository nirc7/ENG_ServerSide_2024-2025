import './App.css'

const apiUrl = 'https://localhost:7265/api/StudentsRW/';

function App() {

  const btnGetAll = () => {
    fetch(apiUrl, {
      method: 'GET',
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res.status', res.status);
        console.log('res.ok', res.ok);
        return res.json()
      })
      .then(
        (result) => {
          console.log("fetch btnFetchGetStudents= ", result);
          result.map(st => console.log(st.name));
          console.log('result[0].name=', result[0].name);
        },
        (error) => {
          console.log("err post=", error);
        });
  }

  const btnGetById = () => {
    fetch(apiUrl + '3', {
      method: 'GET',
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res.status', res.status);
        console.log('res.ok', res.ok);
        return res.json()
      })
      .then(
        (result) => {
          console.log("fetch btnFetchGetStudents= ", result);
          console.log('result.name=', result.name);
        },
        (error) => {
          console.log("err post=", error);
        });
  }

  const btnPost = () => {

    const data = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
      Id: 0,
      Name: 'nir',
      Grade: 77
    };

    fetch(apiUrl, {
      method: 'POST',
      body: JSON.stringify(data),
      headers: new Headers({
        'Content-type': 'application/json; charset=UTF-8', //very important to add the 'charset=UTF-8'!!!!
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        return res.json()
      })
      .then(
        (result) => {
          console.log("fetch POST= ", result);
          console.log(result.grade);
          console.log(result.id);
        },
        (error) => {
          console.log("err post=", error);
        });

  }

  const btnPut = () => {
    const data = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
      Id: 11,
      Name: 'name11',
      Grade: 111
    };

    fetch(apiUrl + '11', {
      method: 'PUT',
      body: JSON.stringify(data),
      headers: new Headers({
        'Content-type': 'application/json; charset=UTF-8', //very important to add the 'charset=UTF-8'!!!!
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res=', res.ok);
        console.log('res=', res.status == 204 ? ':)' : '>(');
      }
        ,
        (error) => {
          console.log("err post=", error);
        });
  }

  const btnDelete = () => {

    fetch(apiUrl + '12', {
      method: 'DELETE',
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res.status', res.status);
        console.log('res.ok', res.ok);
      },
        (error) => {
          console.log("err post=", error);
        });
  }

  return (
    <>

      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={btnGetAll}>Get All Studnets</button> <br />
        <button onClick={btnGetById}>Get By Id</button> <br />
        <button onClick={btnPost}>Insert Post</button> <br />
        <button onClick={btnPut}>Update Put</button> <br />
        <button onClick={btnDelete}>Delete</button> <br />
      </div>
    </>
  )
}

export default App
