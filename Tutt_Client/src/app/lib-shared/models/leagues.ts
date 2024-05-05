export interface Leagues {
    id: string
    _etag: Etag
    country: Country
    league: League
    seasons: Season[]
    isshow: boolean
}

export interface Etag {
    timestamp: number
    machine: number
    pid: number
    increment: number
    creationTime: string
}

export interface Country {
    name: string
    code: string
    flag: string
}

export interface League {
    id: number
    name: string
    type: string
    logo: string
}

export interface Season {
    year: number
    start: string
    end: string
    current: boolean
    coverage: Coverage
}

export interface Coverage {
    fixtures: Fixtures
    standings: boolean
    players: boolean
    top_scorers: boolean
    top_assists: boolean
    top_cards: boolean
    injuries: boolean
    predictions: boolean
    odds: boolean
}

export interface Fixtures {
    events: boolean
    lineups: boolean
    statistics_fixtures: boolean
    statistics_players: boolean
}
