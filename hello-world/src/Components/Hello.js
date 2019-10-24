import React, {Component} from 'react';
  


const Hello=()=>{/*<div id="test" className="test">
            <h1>
                Helloconst
            </h1>
        </div>*/
    return React.createElement('div',
    {className:'test',id:'tets'},
        React.createElement('h1',null,'hello ohne jsx')
    );
        
        
    
}

 

export default Hello;