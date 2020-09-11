import React, {Component} from 'react';
import './style.css';

export class WinnerCard extends Component {

    constructor(props){
        super(props);
    }

    render(){
        return (
            <div id={this.props.movie.id} className="winner-movie-card">
                <div className="winner-movie-place">
                    {this.props.place}º
                </div>
                
                <div className="winner-movie-info">
                    <div className="winner-movie-title">{this.props.movie.titulo}</div>
                    <div className="winner-movie-year">{this.props.movie.ano}</div>
                </div>
                
            </div>
        )
    }

}