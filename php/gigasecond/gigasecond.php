<?php

/**
 * Optimised for succinctness
 *
 * @param DateTime $start
 * @return DateTime
 * @throws Exception
 */
function from(DateTime $start) : DateTime
{
    return (clone $start)->add(new DateInterval('PT1000000000S'));
}
