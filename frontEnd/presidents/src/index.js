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
            'orderColumn': "",
            'currentOrder': "Change to Descending order"
        };
    }
    componentDidMount(){
        this.getPresidents();
    }

    updateOrderColum(selectedColumn){
        this.state.orderColumn = selectedColumn;
        console.log(this.state.orderColumn);
        this.updateOrderMode();
    }

    updateOrderMode(){
        this.state.orderDescending = !this.state.orderDescending;
        this.getPresidents();
    }

    getPresidents(){
        fetch('https://president-api.azurewebsites.net/api/president/getListOfPresidents?orderDescending='+this.state.orderDescending+'&orderColumn='+this.state.orderColumn)
        .then(results => results.json())
        .then(results => this.setState({'presidents': results}));

    }
    render(){
        return (
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>President <button onClick={(e) => this.updateOrderColum('PresidentName',e)}>-</button></th>
                            <th>Birthday <button onClick={(e) => this.updateOrderColum('Birthday',e)}>-</button></th>
                            <th>Birthplace<button onClick={(e) => this.updateOrderColum('Birthplace',e)}>-</button></th>
                            <th>Deathday<button onClick={(e) => this.updateOrderColum('Deathday',e)}>-</button></th>
                            <th>Deathplace<button onClick={(e) => this.updateOrderColum('Deathplace',e)}>-</button></th>
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
