
export interface Contact {
    avatar :string,
    username :string
}

export interface Post {
    Id :string,
    Content :string,
    CreatedAt :string,
    EditedAt? :string,
    ImageUrls? :string[]
    PreviousPostId? :string
}