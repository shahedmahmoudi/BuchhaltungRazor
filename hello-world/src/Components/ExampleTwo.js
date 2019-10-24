import React,{Component} from 'react';

class ExampleTwo extends Component{
    constructor(){
        super();
        this.state={
            counter:1
        }
       // this.one=this.one.bind(this);
    }
     one(){
this.setState((prevstate) => ({
    counter: prevstate.counter+1
}))
console.log(this.state.counter);
}
   two(){
       this.one();
       this.one();
   }
    render(){
        return(
            <div>
        <h1>{this.state.counter}</h1>
        <button onClick={this.one}>Operation</button>
        </div>
        );
    }
}

export default ExampleTwo;