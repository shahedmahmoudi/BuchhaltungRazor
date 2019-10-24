import React, {Component} from 'react';

  class ExampleOne extends Component{
      constructor(){
          super();
          this.state={wellcome:'Hello shahed '}
      }

ClickButton(){
    this.setState({wellcome:'Thanks'});
    
}

 

      render(){
          return (
              <div>
          <h1>hello example one {this.state.wellcome}</h1>
          <button onClick={()=>{this.ClickButton()}} >Like</button>
          </div>
          );
      }
  }

  export default ExampleOne;