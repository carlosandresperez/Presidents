import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import { isTemplateElement } from '@babel/types';

class Presidents extends React.Component{
    constructor(){
        super();
        this.state = {
            'presidents': [],
            'orderDescending': false,
            'currentOrder': "Change to Descending order"
        };
    }
    componentDidMount(){
        this.getPresidents();
    }

    updateOrderMode(){
        this.state.orderDescending = !this.state.orderDescending;
        this.getPresidents();
        if (this.state.orderDescending){
            this.state.currentOrder = "Change to Ascending order"
        }
        else{
            this.state.currentOrder = "Change to Descending order"
        }
    }

    getPresidents(){
        fetch('https://president-api.azurewebsites.net/api/president/getListOfPresidents?orderDescending='+this.state.orderDescending)
        .then(results => results.json())
        .then(results => this.setState({'presidents': results}));

    }
    render(){
        return (
            <div>
                <button onClick={(e)=> this.updateOrderMode(e)}>-{this.state.currentOrder}</button>
                <table>
                    <thead>
                        <tr>
                            <th>President</th>
                            <th>Birthday</th>
                            <th>Birthplace</th>
                            <th>Deathday</th>
                            <th>Deathplace</th>
                        </tr>
                    </thead>
                    <tbody>{this.state.presidents.map(function(item, index){
                        return (
                            <tr key= {index}>
                                <td>{item.presidentName}</td>
                                <td>{item.birthday}</td>
                                <td>{item.birthplace}</td>
                                <td>{item.deathday}</td>
                                <td>{item.deathplace}</td>
                            </tr>
                        )
                    })}
                    </tbody>
                </table>
            </div>
        );
    }

};

ReactDOM.render(<Presidents />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
