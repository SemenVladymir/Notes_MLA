import './App.css';
import { Component } from 'react';
class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      phones: []
    }
  }

  API_URL = "https://localhost:7174/";

  componentDidMount() {
    this.refreshPhones();
}

  async refreshPhones() {
    fetch(this.API_URL + "api/phone/GetPhones").then(response => response.json())
      .then(data => { this.setState({ phones: data }); })
  }


  async addClick() {
    var PhoneName = document.getElementById("Name").value;
    var PhoneCompany = document.getElementById("Company").value;
    var PhonePrice = document.getElementById("Price").value;
    const data = new FormData();
    data.append("Name", PhoneName);
    data.append("Company", PhoneCompany);
    data.append("Price", PhonePrice);

    fetch(this.API_URL + "api/phone/AddPhone", {
      method: "POST",
      body: data
    }).then(res => res.json()).then((result) => {
      alert(result);
      this.refreshPhones();
    }) 
  }

  async deleteClick(id) {
    
    fetch(this.API_URL + "api/phone/DeletePhone?id="+id, {
      method: "DELETE",
    }).then(res => res.json()).then((result) => {
      alert(result);
      this.refreshPhones();
    }) 
  }


  render() {
    const { phones } = this.state;
  return (
    <div className="App">
      <h2>Work with the phone list</h2>
      <label> Phone name </label>
      <input id="Name" />&nbsp;
      <p/>
      <label> Company </label>
      <input id="Company" />&nbsp;
      <p/>
      <label> Price </label>
      <input id="Price" />&nbsp;
      <p/>
    <button onClick={()=>this.addClick()}>Add phone</button>
    <p/><p/>
        <table className='table table-striped' aria-labelledby="tabelLabel">
  <thead>
    <tr>
      <th>Id</th>
      <th>Phone name</th>
      <th>Company</th>
      <th>Price, hrn</th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    {phones.map(phone =>
      <tr key={phone.Id}>
        <td>{phone.Id}</td>
        <td>{phone.Name}</td>
        <td>{phone.Company}</td>
        <td>{phone.Price}</td>
        <td><button onClick={()=>this.deleteClick(phone.Id)}>Delete phone</button></td>
      </tr>
    )}
  </tbody>
</table>
    </div>
  );
}
}
export default App;
