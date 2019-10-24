import React,{Component} from 'react'
import ReactDOM from 'react-dom'

class SilperRengeInput extends Component{
    constructor(){
        super();
        this.state={
            red:0 
        }
        this.update=this.update.bind(this)
    }
    update(e){
        this.setState({
            red:ReactDOM.findDOMNode(this.refs.red.refs.inp).value 
        })
    }
   
    render(){
        return(
            <div>
               
                <NumInput 
                ref="red" 
                min={0}
                max={255}
                step={1}
                val={+this.state.red}
                lable="Red"
                type="range"               
                update={this.update} />
                <hr/>
               {this.state.red}
                
            </div>
        );
    }
}

class NumInput extends Component{
    render(){
        let lable=this.props.lable!==''?
        <lable>{this.props.lable} - {this.props.val}</lable>:''
       return(
           <div>
               <input ref="inp" 
               type={this.props.type} 
               min={this.props.min}
               max={this.props.max}
               step={this.props.step}
               defaultValue={this.props.val}
               onChange={this.props.update}/>             
           </div>
       );
    }

}


// NumInput.propTypes={
//     min:React.propTypes.number,
//     max:React.propTypes.number,
//     step:React.propTypes.number,
//     val:React.propTypes.number,
//     lable:React.propTypes.string,
//     update:React.propTypes.func.isRequired,
//     type:React.propTypes.oneOf(['number','range'])
// }

NumInput.defaultProps={
    min:0,
    max:0,
    step:1,
    val:0,
    lable:'',
    type:'range'
}


export default SilperRengeInput