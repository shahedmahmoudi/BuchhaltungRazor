import React,{Component} from 'react';

class ConditionExample extends Component{
    constructor(props){
        super(props);
        this.state={vaziatSt:false};
    }
    render(){
        return(
           <h1>jhgsjfsd</h1>
        );
        // let message='';
        // if(this.state.vaziatSt)
        // {
        // message=<div><h1>heloooooo</h1></div>
        //     }
        //     else{
        //     message=<div><h1>byeeeee</h1></div>
        //     }

       /* if(this.state.vaziatSt){
        return(
            <div>
                <h1>hi trueee</h1>
            </div>
        )        
    }else{
        return(
        <div>
        <h1>hi falseeee</h1>
    </div>)
    }*/
    //return(this.state.vaziatSt?<div><h1>heloooooo</h1></div>:<div><h1>byee</h1></div>);
    }
    
}

export default ConditionExample;