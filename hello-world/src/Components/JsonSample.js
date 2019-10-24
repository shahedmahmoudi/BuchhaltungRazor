import React,{Component} from 'react'


class JsonSample extends Component{
constructor(){
    super();
    this.state={items:[]
     
    }    
}
componentWillMount(){

    fetch('https://swapi.co/api/people/?page=2&format=json')
    .then(response=>response.json())
    .then(({results:items})=>this.setState({items}))
}
filt(e){
this.setState({filter:e.target.value})
}
render(){

    let items=this.state.items
    if(this.state.filter){
        items=items.filter(item=>
item.name.toLowerCase()
.includes(this.state.filter.toLowerCase()))        
    }
    return(
        <div>  
            <input type="text" onChange={this.filt.bind(this)}/>        
           { items.map(item=> 
           <Person key={item.name}  person={item} />  )}
           <h1>...</h1>       
        </div>
    );
}
} 

const Person=(props)=><h4>{props.person.name}</h4>
export default JsonSample