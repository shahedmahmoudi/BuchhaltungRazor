import React,{Component} from 'react'

class CloneElementCh extends Component{
    constructor(){
        super();
        this.state={ selected:"None" }
    }
    selectItem(selected){
this.setState({selected})
    }
            render(){
                let fn =child=>
                React.cloneElement(child,{
                    onClick: this.selectItem.bind(this,child.props.value)

                })
                let items=React.Children.map(this.props.children,fn);
                return(
                    <div>
                   <input type="range"
                   min="0"
                   max="2220"/>
                   <h2> you selected : {this.state.selected}</h2>
                 {items}
                    </div>
                );
                }
}   

export default CloneElementCh