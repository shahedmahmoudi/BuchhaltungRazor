import React,{Component} from 'react';
import PropTypes from 'prop-types';

class OnChangeInput extends Component{
    constructor(props){
        super(props);
this.state={
    txt:props.Val,
    Nu:props.Num1
}
    }
    update1(e)
    {
        this.setState({txt:e.target.value});
    }
      update12 (e) 
    {
        alert('shahed');
    }
    render(){
        return (
            <div> 
           
           
            <h1>{this.state.txt}----{this.state.Nu}</h1>
            <input type="text"
             onChange={this.update1.bind(this)}/>

<button onClick={this.update12.bind(this)}>I <Heart/> React</button>
        </div>
 
            );

    }
    
}

  
 class Heart extends React.Component{
     render(){
         return <span>&hearts;</span>
     }
 }
OnChangeInput.defaultProps={
    Val:"default shahed",
    Num1:"10153"
}

export default OnChangeInput;