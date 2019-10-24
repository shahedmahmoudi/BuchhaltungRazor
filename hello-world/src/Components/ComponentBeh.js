import React,{Component} from 'react'

const HOC =(InnerComponet)=>class extends Component{
    constructor(){
    super()
    this.state={count:0}    
    }

    update(){
        this.setState({count:this.state.count+1})
    }
    componentWillMount(){
        console.log('  Mount')
    }
    render(){
        return(
            <InnerComponet
            {...this.props}
            {...this.state}
           update= {this.update.bind(this)}
            />
        );
    }
}


class ComponentBeh extends Component{
    constructor(){
        super()                   
        } 
        render(){
            return(
                <div>
                    <Button>button</Button>
                    <hr/>
                    <LableHOC>label</LableHOC>
                </div>
            );
        }
    }

    const Button=HOC((props)=><button onClick={props.update}> {props.children}-{props.count}</button>)

    class Lable extends Component{
        componentWillMount(){
            console.log('Label Mount')
        }
        render(){
            return(
                <labl onMouseMove={this.props.update}>{this.props.children}-{this.props.count}</labl>
            );
        }
    }
const LableHOC=HOC(Lable)
    export default ComponentBeh
