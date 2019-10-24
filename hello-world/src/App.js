import React from 'react';
import logo from './logo.svg';
import './App.css'; 
import SilperRengeInput from './Components/SliperRengeInput';
 
function Clock(props) {
  return (
    <div>
      <h1>Hello, world!</h1>
      <h2>It is {props.date.toLocaleTimeString()}.</h2>
    </div>
  );
} 

function App() {
  return (
    /*<div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" /> 
             
         <LiveCompiler   />
          <Clock date={new Date()} />                 
      </header>
    </div>

    <div>
    
     <CloneElementCh>
       <button value="A">A</button>
       <button value="B">B</button>
       <button value="C">C</button>
     </CloneElementCh>
    </div>*/
    <div>
      <SilperRengeInput/>
    </div>
  );
  }
   
export default App;
