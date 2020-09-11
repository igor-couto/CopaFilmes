import React, { Component } from 'react';
import { MovieCard } from '../MovieCard';
import { WinnerCard } from '../WinnerCard';
import './styles.css';

export class MovieList extends Component {

    constructor(props){
        super(props);
    }

    render() {

        if(this.props.winners === null || this.props.winners.length === 0)
            return (
                <div id="movie-list">
                    {
                    this.props.movies.map( movie => (
                            <MovieCard 
                                key={movie.id}
                                movie={movie}
                                onCardSelect = {this.props.onCardSelect}
                            />
                        ))
                    }
                </div>
            );
        else
            return(
                <div id="movie-list">
                    {
                    this.props.winners.map( (movie, i) => (
                        <WinnerCard
                            key={movie.id}
                            movie={movie}
                            place={i + 1}
                        />
                        ))
                    }
                </div>
            );    
    }

}